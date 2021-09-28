import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AccountService } from '../account/services/account.service';

import { Error } from '../common/models/error';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

    constructor(private toastr: ToastrService, private router: Router, private accountService: AccountService) {}

    public intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return next.handle(request)
                    .pipe(catchError((response: any) => {
                                let error = new Error();
                        
                                if (response.status === 0) {
                                    error.source = "app";
                                    error.description = "Ocorreu um erro desconhecido. Verifique sua conexão com a internet.";

                                    this.toastr.error(error.description);

                                    return throwError([error]);
                                }

								if (response.status === 401) {
                                    this.accountService.logout();

									this.router.navigate(["/account"]);

                                    return throwError([response]);
                                }
                        
                                if (response.status === 500) {
                                    error.source = "app";
                                    error.description = "Ocorreu um erro interno. Tente novamente mais tarde.";

                                    this.toastr.error(error.description);

                                    return throwError([error]);
                                }   
                                
                                if(response.error)
                                    return throwError(response.error);
                                
                                return throwError(response);
                            })
                    );
    };  
}

export const httpErrorInterceptorProviders = [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
];
