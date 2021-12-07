import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from '../common/guards/authorize.guard';
import { AdComponent } from './components/ad/ad.component';

const routes: Routes = [
	{ path: ':id', component: AdComponent, canActivate: [AuthorizeGuard], data: { authorize: false, guest: false } }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdvertisingRoutingModule { }
