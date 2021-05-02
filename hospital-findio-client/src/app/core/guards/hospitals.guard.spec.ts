import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterTestingModule } from '@angular/router/testing';
import { FindioApiService } from '@app/services/findio-api.service';
import { ToastrModule } from 'ngx-toastr';

import { HospitalsGuard } from './hospitals.guard';

describe('HospitalsGuard', () => {
	let guard: HospitalsGuard;
	let service: FindioApiService;

	beforeEach(() => {
		TestBed.configureTestingModule({
			imports: [
				RouterTestingModule,
				HttpClientModule,
				ToastrModule.forRoot({
					positionClass: 'toast-bottom-right'
				})
			]
		});
		guard = TestBed.inject(HospitalsGuard);
		service = TestBed.inject(FindioApiService);
	});

	it('should be created', () => {
		expect(guard).toBeTruthy();
	});

	it('should disallow activate', () => {
		guard.canActivate().subscribe((response) => {
			expect(response).toBeFalsy();
		});
	});

	it('should allow activate', () => {
		service.levelOfPainSource.next(0);
		guard.canActivate().subscribe((response) => {
			expect(response).toBeTruthy();
		});
	});

	it('should disallow activate when value too low', () => {
		service.levelOfPainSource.next(-1);
		guard.canActivate().subscribe((response) => {
			expect(response).toBeFalsy();
		});
	});
});
