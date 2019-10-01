import { Injectable } from '@angular/core';
import { SettingsModel } from '../models/settings.model';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';



@Injectable(
    { providedIn: 'root' }
)

export class SettingsHelperService {
    private setting: SettingsModel;

    constructor(private http: HttpClient) {

    }

    async getSettingsAsync(): Promise<SettingsModel> {
        if (this.setting === undefined) {
            this.setting = await this.loadSettingsFromSiteRootAsync();
        }
        return this.setting;
    }

    private async loadSettingsFromSiteRootAsync(): Promise<SettingsModel> {
        return await this.http.get('assets/settings.json')
            .pipe(map(val => new SettingsModel(val)))
            .toPromise();
    }
}