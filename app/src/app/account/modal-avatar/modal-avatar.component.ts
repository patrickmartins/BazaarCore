import { AfterViewInit, Component, OnDestroy, ViewChild } from '@angular/core';
import { MDBModalRef } from 'angular-bootstrap-md';

import { Error } from 'src/app/common/models/error';
import { ImageService } from 'src/app/image/services/image.service';
import { AccountService } from '../services/account.service';
import { CroppieOptions, ResultOptions } from 'croppie';
import { NgxSuperCroppieComponent } from 'ngx-super-croppie';

@Component({
  selector: 'modal-avatar',
  templateUrl: './modal-avatar.component.html',
  styleUrls: ['./modal-avatar.component.css']
})
export class ModalAvatarComponent implements AfterViewInit, OnDestroy {   
	
	@ViewChild('croppie') public croppie: NgxSuperCroppieComponent | undefined;
	
    public imageChangeEvent: any;
    public changingAvatar: boolean = false;
	public uploadingAvatar: boolean = false;
	
	public errors: Error[] = [];

	public croppedImage!: Blob;
	
	public croppieOptions: CroppieOptions = {
		boundary: { width: 450, height: 450 },
		enableExif: true,
		enableZoom: true,
		enforceBoundary: true,
		enableResize: false,
		mouseWheelZoom: true,
		showZoomer: true,
		viewport: { width: 250, height: 250, type: 'circle' },
	};

	public resultOptions: ResultOptions = {
		type: 'blob',
		size: 'viewport',
		format: 'jpeg',
		quality: 1,
		circle: false,
	};

    constructor(public modalRef: MDBModalRef, private accountService: AccountService, private imageService: ImageService) {	}

	public ngAfterViewInit(): void {
		this.croppie?.result.subscribe((crop: Blob) => this.croppedImage = crop);

		if (!this.imageChangeEvent.target)
			return;
		
		let file = this.imageChangeEvent.target.files[0];
		
		let reader = new FileReader();

		reader.onloadend = () => {
			if(reader.result && this.croppie)
				this.croppie.url = reader.result.toString();
		};
	
		reader.readAsDataURL(file);
	}

	public ngOnDestroy(): void {
		this.croppie?.destroy();
	}

    public changeAvatar() {
		this.uploadingAvatar = true;

		this.imageService
			.uploadAvatar(this.croppedImage)
			.subscribe(
				(guid: string) => 
				{
					this.changingAvatar = true;

					this.accountService
						.changeAvatar(guid)
						.subscribe(
							() => this.modalRef.hide(),
							(errors: Error[]) => { this.errors = errors }
						)
						.add(() => this.changingAvatar = false);
				},
				(errors: Error[]) => { this.errors = errors }
			)
			.add(() => this.uploadingAvatar = false);
    }

}
