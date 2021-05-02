import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { IIllness } from '@shared/models/illness.model';
import { FindioApiService } from '@app/services/findio-api.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-patient-form',
	templateUrl: './patient-form.component.html',
	styleUrls: ['./patient-form.component.scss']
})
export class PatientFormComponent implements OnInit {
	patientFormGroup: FormGroup;

	illnesses: IIllness[] = [];
	illnesses$: Observable<IIllness[]>;

	searchField = new FormControl('');

	constructor(
		private formBuilder: FormBuilder,
		private findio: FindioApiService,
		private router: Router,
		private toastr: ToastrService
	) {
		this.patientFormGroup = this.formBuilder.group({
			name: [
				'',
				[
					Validators.required,
					Validators.minLength(4),
					Validators.pattern(/^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$/)
				]
			],
			illnessId: ['', [Validators.required, Validators.min(0)]],
			levelOfPain: [0, [Validators.required, Validators.min(0), Validators.max(4)]]
		});
		this.illnesses$ = new Observable<IIllness[]>();
		this.findio.getIllnesses().subscribe((response) => {
			this.illnesses = response;
			this.illnesses$ = this.searchField.valueChanges.pipe(
				startWith(''),
				map((value) => this.search(value))
			);
		});
	}

	ngOnInit() {}

	onSubmit() {
		console.log('hah');
		if (this.patientFormGroup.valid) {
			this.findio.postPatientData(this.patientFormGroup.value).subscribe((respone) => {
				console.log(respone);
			});
			this.findio.levelOfPainSource.next(this.levelOfPain);
			this.router.navigate(['/hospitals']);
		} else {
			this.toastr.error('Please fill the patient form first!');
		}
	}

	get levelOfPain() {
		return this.patientFormGroup.get('levelOfPain')?.value;
	}

	get name() {
		return this.patientFormGroup.get('name')!;
	}

	private search(text: string): IIllness[] {
		return this.illnesses.filter((illness) => {
			const term = text.toLowerCase();
			return illness.name.toLowerCase().includes(term);
		});
	}
}
