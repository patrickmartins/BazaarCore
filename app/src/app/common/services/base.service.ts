import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IModel } from '../models/model';

export abstract class BaseService {

    constructor(private httpClient: HttpClient) { }

	protected post<TType>(url: string, data: any): Observable<TType>;
	protected post<TType>(url: string, data: any, options: any, returnType?: (new () => IModel<any>)): Observable<TType>;
    protected post<TType>(url: string, data: any, options?: any, returnType?: (new () => IModel<any>)): Observable<TType> {
        return this.httpClient
            .post(url, data, options)
            .pipe(
                map(response => this.sucessHandler(response, returnType))
            );
    }

    protected get<TType>(url: string, returnType: (new () => IModel<any>), options?: any): Observable<TType>;
	protected get<TType>(url: string, returnType: (new () => IModel<any>), options: any, params?: any): Observable<TType>;
	protected get<TType>(url: string, returnType: (new () => IModel<any>), options?: any, params?: any): Observable<TType> {
		if(params) {
			let httpParams = this.parseToHttpParams(params);

			if(!options) {
				options = {};
			}

			options.params = httpParams;
		}

        return this.httpClient
            .get<TType>(url, options)
            .pipe(
                map(response => this.sucessHandler(response, returnType))
            );
    }

	private parseToHttpParams(params: any): HttpParams {
		let httpParams = new HttpParams();

		Object.keys(params).forEach(key => {
			let value = (params as any)[key];
			
			if(value) {
				if(Array.isArray(value)) {
					value.forEach(c => httpParams = httpParams.append(key, c));
				} else {
					httpParams = httpParams.append(key, value);
				}				
			}
		});

		return httpParams;
	}

    private sucessHandler<TType>(response: any, returnType?: (new () => IModel<any>)): TType {
        if (response && returnType) {
			let entity = new returnType();

			if(Array.isArray(response)) {			
				var array = new Array<TType>();
				
				response.forEach(item => array.push(entity.createNew(item)));

				return array as any;
			}			

			return entity.createNew(response);
		}
		
        return response;
    }
}