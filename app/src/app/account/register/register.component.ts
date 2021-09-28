import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Factory } from 'src/app/common/factories/factory';
import { FormBaseComponent } from 'src/app/common/form/form-base.component';
import { Error } from 'src/app/common/models/error';
import { RegisterModel } from '../models/register';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent extends FormBaseComponent<RegisterModel> {

    public registering: boolean = false;

    constructor(private accountService: AccountService, private router: Router) {
        super(new Factory<RegisterModel>(RegisterModel));
    }

    public register() {
        if(this.form.valid) {
            let model = this.getModel();
            
            this.registering = true;

            this.accountService
                .register(model)
                .subscribe(
                    () => this.router.navigate(["/account/login"]),
                    (errors: Error[]) => {
                        this.clearValidationErrors();
                        this.addValidationErrors(errors);
                        
                        this.registering = false;
                    }
                );
        }
    }
}
