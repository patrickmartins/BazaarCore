import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { BaseService } from 'src/app/common/services/base.service';
import { SearchAdModel } from 'src/app/search/models/search';
import { environment } from 'src/environments/environment';
import { AdBasicModel } from '../../advertising/models/ad-basic';
import { AdDetailed } from '../../advertising/models/ad-detailed';
import { QuestionModel } from '../../advertising/models/question';
import { ResponseModel } from '../../advertising/models/response';

@Injectable({
  providedIn: 'root'
})
export class AdvertisingService extends BaseService {

	constructor(httpClient: HttpClient) {
		super(httpClient);
	}

    public getMostRecent(maxResults: number): Observable<AdBasicModel[]> {
        return this.get<AdBasicModel[]>(`${environment.urlBase}ad/most-recent/${maxResults}`, AdBasicModel);
    }

	public getById(id: string): Observable<AdDetailed> {
        return this.get<AdDetailed>(`${environment.urlBase}ad/${id}`, AdDetailed);
    }
	
	public ask(idAd: string, question: QuestionModel): Observable<string> {
        return this.post(`${environment.urlBase}ad/${idAd}/ask`, question);
    }

	public answer(idAd: string, idQuestion: string, response: ResponseModel): Observable<string> {
        return this.post(`${environment.urlBase}ad/${idAd}/question/${idQuestion}/answer`, response);
    }

	public search(filters: SearchAdModel): Observable<AdBasicModel[]> {
        return this.get(`${environment.urlBase}ad/search`, AdBasicModel, { }, filters);
    }
}