import { Routes } from '@angular/router';

import { DashboardComponent } from 'src/app/pages/dashboard/dashboard.component';
import { IconsComponent } from 'src/app/pages/icons/icons.component';
import { MapsComponent } from 'src/app/pages/maps/maps.component';
import { TablesComponent } from 'src/app/pages/tables/tables.component';
import { UserProfileComponent } from 'src/app/pages/user-profile/user-profile.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent }
];
