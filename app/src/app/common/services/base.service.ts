import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { copy } from 'src/app/helpers/object-copy';

import { Factory } from '../factories/factory';

export abstract class BaseService {

    constructor(private httpClient: HttpClient) { }

    post(url: string, data: any, options?: any): Observable<any>;
    post<TType>(url: string, data: any, options?: any, factory?: Factory<TType>): Observable<TType>;
    post(url: any, data: any, options?: any, factory?: any) {
        return this.httpClient
            .post(url, data, options)
            .pipe(
                map(response => this.sucessHandler(response, factory))
            );
    }

    protected get<TType>(url: string, factory: Factory<TType>, options?: any): Observable<TType> {
        return this.httpClient
            .get<TType>(url, options)
            .pipe(
                map(response => this.sucessHandler(response, factory))
            );
    }

    private sucessHandler(response: any, factory?: Factory<any>) {
        if (response && factory)
            return copy(factory.create(), response);

        return response;
    }
}