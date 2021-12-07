import { LOCALE_ID, NgModule } from '@angular/core';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import { CommonModule, registerLocaleData } from '@angular/common';
import localePT from '@angular/common/locales/pt';
import { ButtonsModule, WavesModule, CarouselModule } from 'angular-bootstrap-md';

import { SharedModule } from '../shared/shared.module';
import { AdvertisingRoutingModule } from './advertising-routing.module';
import { AdvertisingComponent } from './advertising.component';
import { AdQuestionComponent } from './components/ad-question/ad-question.component';
import { AdComponent } from './components/ad/ad.component';
import { CarouselPicturesComponent } from './components/carousel-pictures/carousel-pictures.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ContentLoaderModule } from '../content-loader/content-loader.module';

registerLocaleData(localePT);

@NgModule({
  declarations: [
	AdComponent,
	AdvertisingComponent,
	CarouselPicturesComponent,
	AdQuestionComponent
  ],
  imports: [
	ButtonsModule, 
	WavesModule,  
	CommonModule,
	LazyLoadImageModule,	
	ReactiveFormsModule,
    AdvertisingRoutingModule,
	CarouselModule,
	SharedModule,
	WavesModule,
	ContentLoaderModule
  ],
  providers: [
	{provide: LOCALE_ID, useValue: 'pt-BR'}
  ]
})
export class AdvertisingModule { }