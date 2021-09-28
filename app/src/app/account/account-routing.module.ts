import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from '../common/guards/authorize.guard';

import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
    { path: '', component: LoginComponent, canActivate: [AuthorizeGuard], data: { authorize: false, guest: true } },
    { path: 'login', redirectTo: '', pathMatch: 'full' },
    { path: 'register', component: RegisterComponent, canActivate: [AuthorizeGuard], data: { authorize: false, guest: true } },
    { path: 'profile', component: ProfileComponent, canActivate: [AuthorizeGuard], data: { authorize: true, guest: false } }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AccountRoutingModule { }
