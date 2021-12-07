import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { ToastrModule } from 'ngx-toastr';
import localePT from '@angular/common/locales/pt';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { httpDefaultInterceptorProviders } from './interceptors/default.interceptor';
import { httpErrorInterceptorProviders } from './interceptors/error.interceptor';
import { AccountService } from './shared/services/account.service';
import { NavigationModule } from './navigation/navigation.module';
import { SharedModule } from './shared/shared.module';
import { registerLocaleData } from '@angular/common';
import { ContentLoaderModule } from './content-loader/content-loader.module';

registerLocaleData(localePT);

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent
    ],
    imports: [    
        BrowserModule,
        NavigationModule,
		SharedModule,
        AppRoutingModule,  
		ContentLoaderModule,     
        BrowserAnimationsModule,		
        MDBBootstrapModule.forRoot(),        
        ToastrModule.forRoot({
            positionClass: 'toast-top-full-width'
        })
    ],	
    providers: [		
		{provide: LOCALE_ID, useValue: 'pt-BR'},
        httpDefaultInterceptorProviders,
        httpErrorInterceptorProviders,
		AccountService
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    bootstrap: [AppComponent]
})

export class AppModule { }
