import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentLoaderModule as LoaderModule } from '@ngneat/content-loader';

import { AdCardLoaderComponent } from './components/ad-card-loader/ad-card-loader.component';
import { AdLoaderComponent } from './components/ad-loader/ad-loader.component';
import { CarouselPicturesLoaderComponent } from './components/carousel-pictures-loader/carousel-pictures-loader.component';
import { AdQuestionLoaderComponent } from './components/ad-question-loader/ad-question-loader.component';

@NgModule({
	declarations: [
		AdCardLoaderComponent,
		AdLoaderComponent,
		CarouselPicturesLoaderComponent,
		AdQuestionLoaderComponent
	],
	imports: [
		CommonModule,
		LoaderModule		
	],
	exports: [
		AdCardLoaderComponent,
		AdLoaderComponent,
		CarouselPicturesLoaderComponent,
		AdQuestionLoaderComponent
	]
})
export class ContentLoaderModule { }
