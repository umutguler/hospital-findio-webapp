import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowHospitalsComponent } from './show-hospitals.component';

describe('ShowHospitalsComponent', () => {
	let component: ShowHospitalsComponent;
	let fixture: ComponentFixture<ShowHospitalsComponent>;
	let h1: HTMLElement;

	beforeEach(async () => {
		await TestBed.configureTestingModule({
			declarations: [ShowHospitalsComponent]
		}).compileComponents();
		h1 = fixture.nativeElement.querySelector('h1');
	});

	beforeEach(() => {
		fixture = TestBed.createComponent(ShowHospitalsComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});
});
