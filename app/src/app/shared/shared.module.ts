import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import { RouterModule } from '@angular/router';
import { AdCardComponent } from './components/ad-card/ad-card.component';
import { ImageService } from './services/image.service';
import { PrettyDatePipe } from './pipes/pretty-date.pipe';

@NgModule({
	declarations: [
		AdCardComponent,
		PrettyDatePipe
	],
	imports: [
		CommonModule,
		LazyLoadImageModule,
		RouterModule,
	],
	providers: [
		ImageService    
    ],
	exports: [
		AdCardComponent,
		PrettyDatePipe
	]
})
export class SharedModule { }
