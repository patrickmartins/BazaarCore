import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../common/services/base.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class ImageService extends BaseService {

	constructor(httpClient: HttpClient) {
		super(httpClient);
  	}

	public uploadAvatar(blob: Blob): Observable<string> {
		var form = new FormData();

		form.append("file", blob, "file");

		return this.post<string>(`${environment.urlBase}image/upload-avatar`, form);		
	}

	public uploadAdPicture(blob: Blob): Observable<string> {
		var form = new FormData();

		form.append("file", blob, "file");

		return this.post<string>(`${environment.urlBase}image/upload-picture-ad`, form);		
	}
}
