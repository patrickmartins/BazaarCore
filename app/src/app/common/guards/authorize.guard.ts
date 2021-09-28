import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';

import { AccountService } from 'src/app/account/services/account.service';

@Injectable({
  providedIn: 'root'
})

export class AuthorizeGuard implements CanActivate {
  
    constructor(private accountService: AccountService, private router: Router) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if (route.data.authorize && !this.accountService.isAuthenticated())
            this.router.navigate(["/login"]);

        if (route.data.guest && this.accountService.isAuthenticated())
            this.router.navigate(["/home"]);

        return true;
    }  

}
