import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule, HAMMER_GESTURE_CONFIG, HammerModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { ContentLoaderModule } from '@ngneat/content-loader';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { httpDefaultInterceptorProviders } from './interceptors/default.interceptor';
import { httpErrorInterceptorProviders } from './interceptors/error.interceptor';
import { AccountService } from './account/services/account.service';
import { NavigationModule } from './navigation/navigation.module';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent
    ],
    imports: [    
        BrowserModule,
        NavigationModule,
        AppRoutingModule,
        ContentLoaderModule,        
        BrowserAnimationsModule,
        MDBBootstrapModule.forRoot(),        
        ToastrModule.forRoot({
            positionClass: 'toast-top-full-width'
        })
    ],
    providers: [		
        httpDefaultInterceptorProviders,
        httpErrorInterceptorProviders,
		AccountService
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    bootstrap: [AppComponent]
})

export class AppModule { }
