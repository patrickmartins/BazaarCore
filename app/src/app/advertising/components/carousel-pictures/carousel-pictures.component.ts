import { Component, Input, ViewChild } from '@angular/core';
import { CarouselComponent } from 'angular-bootstrap-md';
import { ImageService } from 'src/app/shared/services/image.service';

@Component({
  selector: 'carousel-pictures',
  templateUrl: './carousel-pictures.component.html',
  styleUrls: ['./carousel-pictures.component.css']
})
export class CarouselPicturesComponent {
	
	@ViewChild("carousel") carousel: CarouselComponent | undefined;

	@Input()
	public picture: string[] = [];
	public selected: number = 0;

  	constructor(public imageService: ImageService) { }

	public selectPicture(index: number)	{
		if(this.carousel) {
			this.carousel.selectSlide(index);		
			this.selected = index;
		}
	}

	public onSelectedPitureChange(event: any) {
		this.selected = event.relatedTarget;
	}
}