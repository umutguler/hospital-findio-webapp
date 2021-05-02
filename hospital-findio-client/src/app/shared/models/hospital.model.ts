import { ILocation } from './location.model';

export interface IHospital {
	id: number;
	levelOfPain: number;
	name: string;
	patientCount: number;
	averageProcessTime: number;
	waitingTime: number;
	location: ILocation;
}
