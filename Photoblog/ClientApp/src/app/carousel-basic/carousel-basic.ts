import { Component } from '@angular/core';

@Component({selector: 'ngbd-carousel-basic', templateUrl: './carousel-basic.html'})
export class NgbdCarouselBasic {
  images = [1, 2, 3].map(() => `https://picsum.photos/1920/1000?random&t=${Math.random()}`);
}
