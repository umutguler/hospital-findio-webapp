import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HospitalsGuard } from '@app/guards/hospitals.guard';
import { PatientFormComponent } from '@modules/find-hospital/components/patient-form/patient-form.component';
import { ShowHospitalsComponent } from '@modules/find-hospital/components/show-hospitals/show-hospitals.component';
import { AboutComponent } from '@modules/home/components/about/about.component';
import { ContactComponent } from '@modules/home/components/contact/contact.component';
import { HomeComponent } from '@modules/home/components/home/home.component';

const routes: Routes = [
	{ path: '', component: HomeComponent },
	{ path: 'about', component: AboutComponent },
	{ path: 'contact', component: ContactComponent },
	{ path: 'patient-details', component: PatientFormComponent },
	{
		path: '',
		runGuardsAndResolvers: 'always',
		canActivate: [HospitalsGuard],
		children: [{ path: 'hospitals', component: ShowHospitalsComponent }]
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {}
