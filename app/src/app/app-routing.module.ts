import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', redirectTo: '', pathMatch: 'full' },
    { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },
	{ path: 'advertising', loadChildren: () => import('./advertising/advertising.module').then(m => m.AdvertisingModule) },
	{ path: 'search', loadChildren: () => import('./search/search.module').then(m => m.SearchModule) }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
