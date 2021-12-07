import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from '../common/guards/authorize.guard';
import { SearchAdComponent } from './components/search-ad/search-ad.component';

const routes: Routes = [
	{ path: '', component: SearchAdComponent, canActivate: [AuthorizeGuard], data: { authorize: false, guest: false }}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SearchRoutingModule { }