import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AdBasicModel } from 'src/app/advertising/models/ad-basic';
import { AdvertisingService } from 'src/app/shared/services/advertising.service';
import { BazaarForm } from 'src/app/common/form/form-base.component';
import { Category } from 'src/app/shared/models/category';
import { SearchAdModel } from '../../models/search';
import { CategoryService } from 'src/app/shared/services/category.service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-search-ad',
  templateUrl: './search-ad.component.html',
  styleUrls: ['./search-ad.component.css']
})
export class SearchAdComponent implements OnInit {

	public searching: boolean = true;

	public filters: SearchAdModel;
	public ads: Array<AdBasicModel>;
	public categories: Array<Category>;

    constructor(private advertisingService: AdvertisingService, private categoryService: CategoryService, private activeRoute: ActivatedRoute, private router: Router) {
		this.filters = new SearchAdModel();
		this.ads = new Array<AdBasicModel>();
		this.categories = new Array<Category>();

		this.getCategories();		
	}

	public ngOnInit() {
		this.activeRoute
			.queryParamMap
			.subscribe((mapParams: any) => {
				this.filters = new SearchAdModel().createNew(mapParams.params) ?? new SearchAdModel();
				
				if(this.filters) {
					this.search();
				} else {
					this.router.navigate(["home"]);
				}
			}); 
	}

	public search() {		
		let form = new BazaarForm<SearchAdModel>(SearchAdModel);

		if(this.filters) {
			form.setModel(this.filters);

			if(form.isValid()) {
				this.advertisingService
						.search(form.getModel())
						.subscribe(result => {
							this.ads = result;
						})
						.add(() => this.searching = false);
			}
		}
	}
	
	public applyFilters() {
		const urlTree = this.router.createUrlTree([], {
			queryParams: this.filters,
			queryParamsHandling: "merge",
			preserveFragment: true });
		
		urlTree.queryParams['r'] = Guid.create();

		this.router.navigateByUrl(urlTree); 
	}

	private getCategories() {
		return this.categoryService
					.getAll()
					.subscribe(categories => this.categories = categories);
	}
}
