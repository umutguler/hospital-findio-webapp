import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { FindioApiService } from '@app/services/findio-api.service';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { isEmpty, map } from 'rxjs/operators';

@Injectable({
	providedIn: 'root'
})
export class HospitalsGuard implements CanActivate {
	constructor(private findio: FindioApiService, private router: Router, private toastr: ToastrService) {}

	canActivate(): Observable<boolean> {
		return this.findio.levelOfPain$.pipe(
			map((level) => {
				console.log(level);
				if (level >= 0) {
					return true;
				} else {
					this.toastr.error('Please fill the patient form first!');
					this.router.navigateByUrl('/patient-details');
					return false;
				}
			})
		);
	}
}
