import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BazaarForm } from 'src/app/common/form/form-base.component';
import { SearchAdModel } from 'src/app/search/models/search';

@Component({
    selector: 'menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})
export class MenuComponent {

	public searchForm: BazaarForm<SearchAdModel>;
    public showSearch: boolean = false;

    constructor(private router: Router) {
		this.searchForm = new BazaarForm<SearchAdModel>(SearchAdModel);
	}

	public search() {
		if(this.searchForm.isValid()) {
			let model = this.searchForm.getModel();

			this.router.navigate(['/search'], { queryParams: model});
		}
	}
}