export class SettingsModel {
    bookApi: string;
    notifyRestartTimeout: number;

    public constructor(init?: Partial<SettingsModel>) {
        Object.assign(this, init);
    }
}
