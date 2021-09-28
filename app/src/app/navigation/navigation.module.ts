import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ContentLoaderModule } from '@ngneat/content-loader';
import { LazyLoadImageModule } from 'ng-lazyload-image';

import { MenuComponent } from './menu/menu.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { MenuLoginComponent } from './menu-login/menu-login.component';
import { NavigationComponent } from './navigation.component';

@NgModule({
    declarations: [
        MenuComponent,
        MenuLoginComponent,
		NavigationComponent
    ],
    imports: [
        FormsModule,
        ReactiveFormsModule,
        ContentLoaderModule,
        LazyLoadImageModule,
        RouterModule,
        CommonModule,
        MDBBootstrapModule,
        HttpClientModule
    ],
    exports: [
        MenuComponent
    ]
})

export class NavigationModule { }
