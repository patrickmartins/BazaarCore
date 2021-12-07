import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { AccountService } from "../shared/services/account.service";

@Injectable()

export class DefaultInterceptor implements HttpInterceptor {

    constructor(private accountService: AccountService) { }

    public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.accountService.isAuthenticated()) {
            let token = this.accountService.getAccessToken();

			if(token) {
				request = request.clone({
					setHeaders: {
						Authorization: `Bearer ${token.accessToken}`
					}
				});
			}
        }

        return next.handle(request);
    }
}

export const httpDefaultInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: DefaultInterceptor, multi: true },
];