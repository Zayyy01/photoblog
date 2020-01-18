import { Component } from '@angular/core';

@Component({selector: 'ngbd-carousel-basic', templateUrl: './carousel-basic.html'})
export class NgbdCarouselBasic {
// ReSharper disable TsResolvedFromInaccessibleModule
  images = [1, 2, 3].map(() => `https://picsum.photos/1920/1000?random&t=${Math.random()}`);
// ReSharper restore TsResolvedFromInaccessibleModule
}
