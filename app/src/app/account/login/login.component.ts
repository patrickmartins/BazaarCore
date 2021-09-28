import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from 'src/app/account/services/account.service';
import { Factory } from 'src/app/common/factories/factory';
import { FormBaseComponent } from 'src/app/common/form/form-base.component';
import { Error } from 'src/app/common/models/error';
import { LoginModel } from '../models/login';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent extends FormBaseComponent<LoginModel> {

    public loggingIn: boolean = false;

    constructor(private accountService: AccountService, private router: Router) {
        super(new Factory<LoginModel>(LoginModel));
    }

    public login() {
        if(this.form.valid) {
            let model = this.getModel();
            
            this.loggingIn = true;

            this.accountService
                .login(model)
                .subscribe(
                    () => this.router.navigate(["/home"]),
                    (errors: Error[]) => {
                        this.clearValidationErrors();
                        this.addValidationErrors(errors);                        
                    }
                )
                .add(() => this.loggingIn = false);				
        }
    }
}
