import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { NavComponent } from './layout/nav/nav.component';
import { FindHospitalModule } from '@modules/find-hospital/find-hospital.module';
import { HomeModule } from '@modules/home/home.module';

@NgModule({
	declarations: [AppComponent, NavComponent],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		AppRoutingModule,
		HttpClientModule,
		HomeModule,
		FindHospitalModule,
		NgbModule,
		ToastrModule.forRoot({
			positionClass: 'toast-bottom-right'
		})
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule {}
