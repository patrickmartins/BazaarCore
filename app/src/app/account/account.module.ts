import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import { ContentLoaderModule } from '@ngneat/content-loader';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NgxSuperCroppieModule } from 'ngx-super-croppie';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { DisableInputsDirective } from '../common/directives/disable-inputs.directive';
import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { ModalAvatarComponent } from './modal-avatar/modal-avatar.component';
import { ImageService } from '../image/services/image.service';

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
        MDBBootstrapModule,     
        FormsModule,
        AccountRoutingModule,
        ReactiveFormsModule,     
        LazyLoadImageModule, 
        ContentLoaderModule,
		NgxSuperCroppieModule,
        CommonModule
    ],
    entryComponents: [ ModalAvatarComponent ],
    providers: [
		ImageService    
    ]
})

export class AccountModule { }
