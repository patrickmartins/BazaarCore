import { Component, Input } from '@angular/core';
import { AdBasicModel } from 'src/app/advertising/models/ad-basic';

@Component({
  selector: 'ad-card',
  templateUrl: './ad-card.component.html',
  styleUrls: ['./ad-card.component.css']
})
export class AdCardComponent {

	@Input()
	public ad!: AdBasicModel;

	constructor() { }

}
