import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from 'src/app/shared/services/account.service';
import { BazaarForm } from 'src/app/common/form/form-base.component';
import { Error } from 'src/app/common/models/error';
import { LoginModel } from '../../models/login';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})

export class LoginComponent {

    public loggingIn: boolean = false;
	public loginForm: BazaarForm<LoginModel>;

    constructor(private accountService: AccountService, private router: Router) {
		this.loginForm = new BazaarForm<LoginModel>(LoginModel);
	}

    public login() {
        if(this.loginForm.isValid()) {
            let model = this.loginForm.getModel();
            
            this.loggingIn = true;

            this.accountService
                .login(model)
                .subscribe(
                    () => this.router.navigate(["/home"]),
                    (errors: Error[]) => {
                        this.loginForm.clearValidationErrors();
                        this.loginForm.addValidationErrors(errors);                        
                    }
                )
                .add(() => this.loggingIn = false);				
        }
    }
}
