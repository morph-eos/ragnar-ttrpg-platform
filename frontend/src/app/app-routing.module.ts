import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TTRPGComponent } from './pages/ttrpg/ttrpg.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  { path: 'ttrpg', component: TTRPGComponent },
  { path: 'login', component: LoginComponent },
  { path: '', component: MainComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
