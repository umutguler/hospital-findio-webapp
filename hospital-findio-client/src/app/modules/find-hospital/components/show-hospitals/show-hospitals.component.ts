import { Component } from '@angular/core';
import { FindioApiService } from '@app/services/findio-api.service';
import { IHospital } from '@shared/models/hospital.model';

@Component({
	selector: 'app-show-hospitals',
	templateUrl: './show-hospitals.component.html',
	styleUrls: ['./show-hospitals.component.scss']
})
export class ShowHospitalsComponent {
	hospitals: IHospital[] = [];
	paginatedHospitals: IHospital[] = [];
	levelOfPain: number = 0;
	pageSize: number = 10;
	page: number = 0;
	collectionSize: number = 0;

	constructor(private findio: FindioApiService) {
		this.findio.levelOfPain$.subscribe((value) => {
			this.levelOfPain = value;
		});

		if (this.levelOfPain >= 0) {
			this.findio.getFastestHospitals(this.levelOfPain).subscribe((response) => {
				this.hospitals = response;
				this.collectionSize = response.length;
				this.refreshTable();
			});
		}
	}

	refreshTable() {
		this.paginatedHospitals = this.hospitals
			.map((hospital, i) => ({ ...hospital }))
			.slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
	}

	convertMinutes(minutes: number) {
		if (minutes < 60) {
			return minutes + ' mins';
		} else {
			return Math.floor(minutes / 60) + ' hr(s) ' + (minutes % 60) + ' mins';
		}
	}
}
