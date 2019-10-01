import { SettingsHelperService } from "./settings-helper.service";
import { Injectable } from "@angular/core";
import { UrlMakerService } from "./url-maker.service";

@Injectable({ providedIn: 'root' })
export class UrlInfoService {
  constructor(private configReader: SettingsHelperService) { }

  async getBookUrlAsync(urlPart: string): Promise<string> {
    const settings = await this.configReader.getSettingsAsync();
    const result = UrlMakerService.getFullUrl(UrlMakerService.getFullUrl(settings.bookApi, 'Book'), urlPart);

    return result;
  }
}
