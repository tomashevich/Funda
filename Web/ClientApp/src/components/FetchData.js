import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { makelaars: [], loading: true };
    }

    componentDidMount() {
        this.populateData();
    }

    static renderTable(makelaars) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Number of aanbods</th>

                    </tr>
                </thead>
                <tbody>
                    {makelaars.map(m =>
                        <tr key={m.makelaarId}>
                            <td>{m.makelaarId}</td>
                            <td>{m.name}</td>
                            <td>{m.numOfProposals}</td>

                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderTable(this.state.makelaars);

        return (
            <div>
                <h1 id="tabelLabel" >Makelaars from Amsterdam</h1>
                <p>This component demonstrates fetching Makelaars from the Amsterdam.</p>
                {contents}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('api/makellaar/top');
        const data = await response.json();
        this.setState({ makelaars: data, loading: false });
    }
}
