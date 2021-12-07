import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Category } from 'src/app/shared/models/category';

@Component({
  selector: 'category-filter',
  templateUrl: './category-filter.component.html',
  styleUrls: ['./category-filter.component.css']
})
export class CategoryFilterComponent {

	@Input()
	public categories!: Array<Category>;

	@Input()
	public selectedsIds: Array<string>;

	@Output()
	public selectedsIdsChange = new EventEmitter<string[]>();

  	constructor() {
		this.selectedsIds = new Array<string>();		
	}

	public changeCategoryFilter(input: any, category: Category) {

		if(input.target.checked){
			if(!this.selectedsIds.includes(category.id)) {
				this.selectedsIds.push(category.id);			
			}
		} else {
			if(this.selectedsIds.includes(category.id)) {
				this.selectedsIds = this.selectedsIds.filter(c => c !== category.id);			
			}
		}
		
		this.selectedsIdsChange.emit(this.selectedsIds);
	}
}
