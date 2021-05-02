import { Component } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-background-carousel',
	templateUrl: './background-carousel.component.html',
	styleUrls: ['./background-carousel.component.scss']
})
export class BackgroundCarouselComponent {
	images = [1, 2, 3, 4].map((n) => `assets/images/${n}.jpg`);

	constructor(config: NgbCarouselConfig) {
		// customize default values of carousels used by this component tree
		config.showNavigationArrows = false;
		config.showNavigationIndicators = false;
		config.keyboard = false;
		config.interval = 5000;
		config.pauseOnFocus = false;
		config.pauseOnHover = false;
	}
}
