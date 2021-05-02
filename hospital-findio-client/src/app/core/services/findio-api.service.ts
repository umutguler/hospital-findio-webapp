import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env';
import { IHospital } from '@shared/models/hospital.model';
import { IIllness } from '@shared/models/illness.model';
import { Observable, ReplaySubject } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class FindioApiService {
	levelOfPainSource = new ReplaySubject<number>(1);
	levelOfPain$ = this.levelOfPainSource.asObservable();

	constructor(private http: HttpClient) {
		this.levelOfPainSource.next(-1);
	}

	getFastestHospitals(levelOfPain: number): Observable<IHospital[]> {
		return this.http.get<IHospital[]>(
			environment.apiUrl + 'hospital/hospitals/fastest?levelOfPain=' + levelOfPain.toString()
		);
	}

	getIllnesses(): Observable<IIllness[]> {
		return this.http.get<IIllness[]>(environment.apiUrl + 'illness/illnesses');
	}

	postPatientData(model: any) {
		return this.http.post(environment.apiUrl + 'patient', model);
	}
}
