import { Component, OnInit } from '@angular/core';

import { AdBasicModel } from '../advertising/models/ad-basic';
import { AdvertisingService } from '../shared/services/advertising.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

	public loadingAds: boolean = true;
	public ads!: AdBasicModel[];

    constructor(private advertisingService: AdvertisingService) { }

    public ngOnInit() {
		this.advertisingService
			.getMostRecent(12)
			.subscribe((result: AdBasicModel[]) => {
				this.ads = result;
			})
			.add(() => this.loadingAds = false);
	}    
}
