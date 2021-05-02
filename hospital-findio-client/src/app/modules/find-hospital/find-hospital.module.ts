import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientFormComponent } from './components/patient-form/patient-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatButtonModule } from '@angular/material/button';
import { MatStepperModule } from '@angular/material/stepper';
import { MatInputModule } from '@angular/material/input';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ShowHospitalsComponent } from './components/show-hospitals/show-hospitals.component';
import { RouterModule } from '@angular/router';

@NgModule({
	declarations: [PatientFormComponent, ShowHospitalsComponent],
	providers: [],
	imports: [CommonModule, RouterModule, ReactiveFormsModule, FormsModule, NgbModule]
})
export class FindHospitalModule {}
