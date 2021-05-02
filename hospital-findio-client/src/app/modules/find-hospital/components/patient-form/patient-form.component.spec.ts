import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterTestingModule } from '@angular/router/testing';

import { PatientFormComponent } from './patient-form.component';
import { ToastrModule } from 'ngx-toastr';

describe('FormComponent', () => {
	let component: PatientFormComponent;
	let fixture: ComponentFixture<PatientFormComponent>;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [PatientFormComponent],
			imports: [
				RouterModule,
				ReactiveFormsModule,
				FormsModule,
				NgbModule,
				HttpClientModule,
				RouterTestingModule,
				ToastrModule.forRoot({
					positionClass: 'toast-bottom-right'
				})
			]
		}).compileComponents();
	});

	beforeEach(() => {
		fixture = TestBed.createComponent(PatientFormComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('form should be invalid to start with', () => {
		expect(component.patientFormGroup.valid).toBeFalsy();
	});

	it('form should be invalid with name field under 4 chars', () => {
		component.patientFormGroup.controls['name'].setValue('Usr');
		component.patientFormGroup.controls['illnessId'].setValue(1);
		component.patientFormGroup.controls['levelOfPain'].setValue(0);
		expect(component.patientFormGroup.valid).toBeFalsy();
	});

	it('form should be valid', () => {
		component.patientFormGroup.controls['name'].setValue('User');
		component.patientFormGroup.controls['illnessId'].setValue(1);
		component.patientFormGroup.controls['levelOfPain'].setValue(0);
		expect(component.patientFormGroup.valid).toBeTruthy();
	});

	it('form should be invalid with illnessId too low', () => {
		component.patientFormGroup.controls['name'].setValue('User');
		component.patientFormGroup.controls['illnessId'].setValue(-1);
		component.patientFormGroup.controls['levelOfPain'].setValue(0);
		expect(component.patientFormGroup.valid).toBeFalsy();
	});

	it('form should be invalid with levelOfPain too low', () => {
		component.patientFormGroup.controls['name'].setValue('User');
		component.patientFormGroup.controls['illnessId'].setValue(0);
		component.patientFormGroup.controls['levelOfPain'].setValue(-1);
		expect(component.patientFormGroup.valid).toBeFalsy();
	});

	it('form should be invalid with levelOfPain too high', () => {
		component.patientFormGroup.controls['name'].setValue('User');
		component.patientFormGroup.controls['illnessId'].setValue(0);
		component.patientFormGroup.controls['levelOfPain'].setValue(5);
		expect(component.patientFormGroup.valid).toBeFalsy();
	});
});
