import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import { ButtonsModule, WavesModule } from 'angular-bootstrap-md';
import { NgxSuperCroppieModule } from 'ngx-super-croppie';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { LoginComponent } from './components/login/login.component';
import { DisableInputsDirective } from '../common/directives/disable-inputs.directive';
import { ModalAvatarComponent } from './components/modal-avatar/modal-avatar.component';
import { ProfileComponent } from './components/profile/profile.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
    declarations: [
        AccountComponent,
        RegisterComponent,
        LoginComponent,
        DisableInputsDirective,
        ProfileComponent,
        ModalAvatarComponent
    ],
    imports: [  
        ButtonsModule, 
		WavesModule,     
        FormsModule,
		LazyLoadImageModule,
        AccountRoutingModule,
        ReactiveFormsModule,
		NgxSuperCroppieModule,
        CommonModule
    ],
    entryComponents: [ ModalAvatarComponent ]
})

export class AccountModule { }
