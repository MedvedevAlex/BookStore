export class UrlMakerService {
    public static getFullUrl(baseUrl: string, path: string): string {
        return this.addTrailingSlash(baseUrl) + this.removeLeadingSlash(path);
    }

    public static removeLeadingSlash(url: string) {
        if (url.startsWith('/')) {
            url = url.substr(1);
        }
        return url;
    }

    public static removeTrailingSlash(value: string): string {
        if (value.endsWith('/')) {
            return value.substr(0, value.length - 1);
        } else {
            return value;
        }
    }

    public static addTrailingSlash(value: string): string {
        if (!value.endsWith('/')) {
            return value + '/';
        } else {
            return value;
        }
    }
}