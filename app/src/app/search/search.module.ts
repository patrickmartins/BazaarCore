import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonsModule, CollapseModule } from 'angular-bootstrap-md';
import { SearchAdComponent } from './components/search-ad/search-ad.component';
import { SearchComponent } from './search.component';
import { SearchRoutingModule } from './search-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ContentLoaderModule } from '../content-loader/content-loader.module';
import { CategoryFilterComponent } from './components/category-filter/category-filter.component';
import { PriceFilterComponent } from './components/price-filter/price-filter.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  	declarations: [
		SearchComponent,
		SearchAdComponent,
		CategoryFilterComponent,
		PriceFilterComponent,
	],
	imports: [
		SearchRoutingModule,
		ContentLoaderModule,
		SharedModule,
		ButtonsModule,
		CollapseModule,
		CommonModule,
		FormsModule
	]
})
export class SearchModule { }
