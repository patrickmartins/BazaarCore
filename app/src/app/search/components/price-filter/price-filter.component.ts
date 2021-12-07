import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'price-filter',
  templateUrl: './price-filter.component.html',
  styleUrls: ['./price-filter.component.css']
})
export class PriceFilterComponent {

	@Input()
	public maxPrice: number = 0;

	@Input()
	public minPrice: number = 0;

	@Input()
	public maxPriceValue: number = 0;

	@Output()
	public maxPriceValueChange = new EventEmitter<number>();

	@Input()
	public minPriceValue: number = 0;

	@Output()
	public minPriceValueChange = new EventEmitter<number>();

  	constructor() { }

	public onChangeMaxPrice(input: any) {
		this.maxPriceValue = input.valueAsNumber;

		this.maxPriceValueChange.emit(this.maxPriceValue);
	}

	public onChangeMinPrice(input: any) {
		this.minPriceValue = input.valueAsNumber;

		this.minPriceValueChange.emit(this.minPriceValue);
	}
}
