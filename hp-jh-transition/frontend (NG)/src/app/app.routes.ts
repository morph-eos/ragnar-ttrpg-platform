import { Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { TTRPGComponent } from './pages/ttrpg/ttrpg.component';

export const routes: Routes = [ 
    { path: 'ttrpg', component: TTRPGComponent },
    { path: 'login', component: LoginComponent },
    { path: '', component: MainComponent }
];
