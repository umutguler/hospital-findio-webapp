import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { BackgroundCarouselComponent } from './components/background-carousel/background-carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { ContactComponent } from './components/contact/contact.component';

@NgModule({
	declarations: [HomeComponent, AboutComponent, BackgroundCarouselComponent, ContactComponent],
	imports: [CommonModule, RouterModule, NgbModule],
	exports: [BackgroundCarouselComponent]
})
export class HomeModule {}
