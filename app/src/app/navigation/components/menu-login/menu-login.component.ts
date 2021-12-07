import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from 'src/app/account/models/user';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
    selector: 'menu-login',
    templateUrl: './menu-login.component.html',
    styleUrls: ['./menu-login.component.css']
})

export class MenuLoginComponent {

	public loggedUser!: User | undefined;

    public get isAuthenticated(): boolean {
        return this.accountService.isAuthenticated();
    }

    constructor(private accountService: AccountService, private router: Router) {
		accountService
			.getLoggedUser()
			.subscribe((user: User | undefined) => {
				 this.loggedUser = user;
			});
	 }

	public logout() {
        this.accountService.logout();
        this.router.navigate(["/home"]);
    }
}