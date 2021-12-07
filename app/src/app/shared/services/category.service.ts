import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BaseService } from 'src/app/common/services/base.service';
import { environment } from 'src/environments/environment';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseService {

	constructor(httpClient: HttpClient) {
		super(httpClient);
	}

	public getAll(): Observable<Category[]> {
		return this.get<Category[]>(`${environment.urlBase}category`, Category);
	}   
}
