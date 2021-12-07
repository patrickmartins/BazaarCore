import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ContentLoaderModule } from '@ngneat/content-loader';
import { LazyLoadImageModule } from 'ng-lazyload-image';

import { MenuComponent } from './components/menu/menu.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NavigationComponent } from './navigation.component';
import { MenuLoginComponent } from './components/menu-login/menu-login.component';

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
        MenuComponent,
		MenuLoginComponent
    ]
})

export class NavigationModule { }
