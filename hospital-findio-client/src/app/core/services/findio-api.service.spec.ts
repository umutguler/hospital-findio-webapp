import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { FindioApiService } from './findio-api.service';

describe('FindioApiService', () => {
	let service: FindioApiService;

	beforeEach(() => {
		TestBed.configureTestingModule({ imports: [HttpClientModule] });
		service = TestBed.inject(FindioApiService);
	});

	it('should initialize levelOfPain', () => {
		service.levelOfPain$.subscribe((response) => {
			expect(response).toEqual(-1);
		});
	});
});
